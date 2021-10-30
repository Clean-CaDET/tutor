<p align="center">
  
  ![Cover](https://raw.githubusercontent.com/wiki/Clean-CaDET/platform/images/overview/cover.jpg)
  
</p>

<h1 align="center">Clean CaDET Tutor</h1>
<div align="center">

  [![CodeFactor](https://www.codefactor.io/repository/github/clean-cadet/tutor/badge)](https://www.codefactor.io/repository/github/clean-cadet/tutor)
  [![Gitter](https://badges.gitter.im/Clean-CaDET/community.svg)](https://gitter.im/Clean-CaDET/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

</div>

<p align="justify">
  The Clean Code and Design Educational Tool (Clean CaDET) is a platform dedicated to the study of clean code. It presents a conglomerate of AI-powered tools for educators, learners, practitioners, and researchers studying clean code. The <a href="https://github.com/Clean-CaDET/platform">original repository</a> currently hosts important class libraries, such as the Code Model and Smell Detectors. From this repository Tutor emerged as a standalone application, which has since migrated to this repository.
  </p>
<p align="justify">
  Clean CaDET started as a project funded by the <a href="http://fondzanauku.gov.rs/?lang=en">Science Fund of the Republic of Serbia</a>. It hopes to grow into an active open-source community dedicated to software engineers' growth and their pursuit to build sustainable, high-quality software.
</p>

- [Introduction](#introduction)
  - [What is the problem?](#what-is-the-problem)
  - [Who is it for?](#a-tool-for-learners-and-educators)
- [Get started](https://github.com/Clean-CaDET/platform/blob/master/SETUP.md)
- [Team](#team)

# Introduction
The vision and high-level idea behind Clean CaDET is described in the [overview video](https://www.youtube.com/watch?v=fBENFfjC49A). 

## What is the problem?
<p align="justify">
  There is a lot of flexibility when crafting software solutions, especially those at a higher level of abstraction. Software engineers have a vast pool of tools and technologies to choose from when assembling contemporary software. This flexibility has an interesting consequence – a requirement can be fulfilled by a near-infinite set of different code configurations. Even when limited to a single programming language and a simple requirement, it is easy to list many code samples that fulfill the requirement using different coding styles and language features.
</p>
<p align="justify">
  While many code solutions can fulfill a requirement, not all of them are acceptable. Some solutions cause subtle bugs, performance loss, or expose security vulnerabilities. Furthermore, many of the possible solutions present another severe but less obvious problem in the form of code smells. Code suffering from sever code smells is hard to understand and modify. Such code harms the software’s maintainability, evolvability, reliability, and testability, introducing technical debt. Unfortunately, removing code smells is not easy, as many code smell definitions are vague and lack a concrete heuristic that can unambiguously determine the smell’s presence.
</p>

## A tool for Learners and Educators
<p align="justify">
A significant module of Clean CaDET is its <b>Tutor</b>. It hosts the learner's model, a collection of learning objects, and instructional rules that select the most appropriate educational content for the particular learner. This functionality is integrated into the code quality analysis workflow, and it can be accessed as a standalone educational tool. By directly interacting with the <b>Tutor</b>, learners can explore various clean code topics and engage with the challenge subsystem to learn how to refactor and analyze code quality in a gamified environment.
<ul>
  <li>For more details regarding the <b>Tutor</b> module, useful for <i>learners and educators</i>, check out the <a href="https://github.com/Clean-CaDET/tutor#readme" target="_blank">module's page</a>.</li>
</ul>
</p>

# Team
<p align="justify">
  Our project team consists of professors and teaching assistants from the Faculty of Technical Sciences, Novi Sad, Serbia. We are part of the Chair of Informatics, an organizational unit that has traditionally been the local center of excellence for both artificial intelligence and software engineering research.
</p>

- The people that make up the Clean CaDET Core are listed [here](https://clean-cadet.github.io/about/).
